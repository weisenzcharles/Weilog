package org.charles.weilog.repository;

import org.charles.weilog.domain.Post;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;

import javax.transaction.Transactional;
import java.util.List;

/**
 * 文章数据库操作接口。
 *
 * @author Charles
 */
public interface PostRepository extends JpaRepository<Post, Long>, JpaSpecificationExecutor<Post> {

    @Query("select b from Post b where b.alias = ?1")
    Post findByAlias(String alias);

    /**
     * Find top list.
     *
     * @param pageable
     *         the pageable
     * @return the list
     */
    @Query("select b from Post b where b.recommend = true ")
    List<Post> findTop(Pageable pageable);

    /**
     * Find by query page.
     *
     * @param query
     *         the query
     * @param pageable
     *         the pageable
     * @return the page
     */
    @Query("select b from Post b where b.title like ?1 and b.content like ?1 ")
    Page<Post> findByQuery(String query, Pageable pageable);

    /**
     * Update views int.
     *
     * @param id
     *         the id
     * @return the int
     */
    @Transactional
    @Modifying
    @Query("update Post b set b.views = b.views+1 where b.id = ?1")
    int updateViews(Long id);

    /**
     * Find group year list.
     *
     * @return the list
     */
    @Query("select function('date_format',b.modifiedTime,'%Y') as year from Post b group by function('date_format',b.modifiedTime,'%Y') order by year desc ")
    List<String> findGroupYear();

    /**
     * Find by year list.
     *
     * @param year
     *         the year
     * @return the list
     */
    @Query("select b from Post b where function('date_format',b.modifiedTime,'%Y') = ?1")
    List<Post> findListByYear(String year);
}