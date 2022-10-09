package org.charles.weilog.repository;

import org.charles.weilog.domain.CommentMeta;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;

/**
 * 评论元数据数据仓库。
 *
 * @author Charles
 */
public interface CommentMetaRepository extends JpaRepository<CommentMeta, Long>, JpaSpecificationExecutor<CommentMeta> {
}