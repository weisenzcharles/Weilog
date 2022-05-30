package org.charles.weilog.repository;

import org.charles.weilog.domain.Posts;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;

/**
 * 文章数据库操作接口。
 *
 * @author Charles
 */
public interface PostRepository extends JpaRepository<Posts, Long>, JpaSpecificationExecutor<Posts> {

}
